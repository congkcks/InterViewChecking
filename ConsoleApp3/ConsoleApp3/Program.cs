using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        String text = @"Đây là địa chỉ
        email userabcguest@xuanthulab.net.vn và
        xyz@gmail.com cần trích xuất";
        String pattern = @"(([^\s.]+)@((.[^\s]+)(\..[^\s]+)))";

        Regex rx = new Regex(pattern);

        // Tìm kiếm.
        MatchCollection matches = rx.Matches(text);
        // In thông báo tìm kiếm.
        Console.WriteLine("Tìm thấy {0} email trong:\n\n  {1}\n\n",
                        matches.Count,
                        text);
        // Xuất kết quả email tìm được
        foreach (Match match in matches)
        {
            GroupCollection groups = match.Groups;
            Console.WriteLine("{0}", groups[0].Value);
        }
    }
}
