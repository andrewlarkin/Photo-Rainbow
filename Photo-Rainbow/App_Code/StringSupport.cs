using System;
using System.Collections.Generic;
using System.Web;

using System.Text.RegularExpressions;
using System.Globalization;
using System.Net;
using System.Linq;

/// <summary>
/// Extends String Class
/// </summary>
public static class StringSupport
{
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static bool IsRegexMatch(this string value, string pattern)
    {
        return Regex.IsMatch(value, pattern);
    }

    public static string UrlEncode(this string value)
    {
        return Uri.EscapeDataString(value);
    }

    public static string UrlDecode(this string value)
    {
        return Uri.UnescapeDataString(value);
    }

    private static readonly string[] Twitter_FORMAT = new[]
    {
        /* Thu Apr 07 06:10:17 +0000 2011 */
        "ddd MMM dd HH:mm:ss zzzz yyyy",
        /* Thu Apr 07 06:10:17 UTC 2011 */
        "ddd MMM dd HH:mm:ss UTC yyyy",
    };

    public static DateTime ToTwitterDateTime(this string input)
    {
        foreach (var format in Twitter_FORMAT)
        {
            DateTime output;
            if (DateTime.TryParseExact(
                input, format, DateTimeFormatInfo.InvariantInfo,
                DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeUniversal,
                out output)
            ) { return output; }
        }

        throw new ArgumentException(
            string.Format("'{0}' is not Twitter's DateTime format", input));
    }

    private static readonly string[] RFC2822_FORMAT = new[]
    {
        /* Thu, 29 Sep 2011 22:53:00 GMT */
        "ddd, dd MMM yyyy HH:mm:ss GMT",
        /* Thu, 29 Sep 2011 22:53:00 +9000 */
        "ddd, dd MMM yyyy HH:mm:ss zzzz",
        /* Thu, 29 Sep 2011 22:53 GMT */
        "ddd, dd MMM yyyy HH:mm GMT",
        /* Thu, 29 Sep 2011 22:53 +9000 */
        "ddd, dd MMM yyyy HH:mm zzzz",
        /* 29 Sep 2011 22:53:00 GMT */
        "dd MMM yyyy HH:mm:ss GMT",
        /* 29 Sep 2011 22:53:00 +9000 */
        "dd MMM yyyy HH:mm:ss zzzz",
        /* 29 Sep 2011 22:53 GMT */
        "dd MMM yyyy HH:mm GMT",
        /* 29 Sep 2011 22:53 +9000 */
        "dd MMM yyyy HH:mm zzzz",
    };

    public static DateTime ToRfc2822DateTime(this string input)
    {
        foreach (var format in RFC2822_FORMAT)
        {
            DateTime output;
            if (DateTime.TryParseExact(
                input, format, DateTimeFormatInfo.InvariantInfo,
                DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeUniversal,
                out output)
            ) { return output; }
        }

        throw new ArgumentException(
            string.Format("'{0}' is not RFC2822 format", input));
    }

    public static string Linkfy(this string input, bool expand_tinyurl = false)
    {
        var r = new Regex(@"https?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");

        return r.Replace(
            input, (MatchEvaluator)( m => {
                var href = m.Value;

                if (expand_tinyurl)
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(href);
                    WebResponse res = req.GetResponse();
                    href = res.ResponseUri.ToString();
                }

                return string.Format(
                    "<a href='{0}'>{1}</a>",
                    href, 
                    HttpUtility.UrlDecode(href));
            })
        );
    }

    const string BASE58 = "123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";

    public static long Base58Decode(this string input)
    {
        return BaseDecode(input, BASE58);
    }

    public static long BaseDecode(string input, string alphabet)
    {
        long decoded = 0, multi = 1;

        foreach (var c in input.Reverse())
        {
            decoded += multi * alphabet.IndexOf(c);
            multi *= alphabet.Length;
        }

        return decoded;
    }
}
