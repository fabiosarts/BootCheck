/*
 * User: Fabian Matias Greevey <fabian_matias@hotmail.com>
 * 
 * Copyright 2018 Fabian Matias Greevey
 * 
 * MIT License
 * 
 * Copyright (c) 2018 fabiosarts
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.IO;
using System.Collections.Generic;

namespace BootCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Boot Checker in C#";

            // create a stack of valid files to check
            Stack<String> filesToCheck = new Stack<string>(args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                if (!File.Exists(args[i]))
                    continue;

                filesToCheck.Push(args[i]);
            }
            Console.WriteLine("{0} files has been found.", filesToCheck.Count);

            // check every file from stack
            while (filesToCheck.Count > 0)
            {
                string path = filesToCheck.Pop();
                FileStream file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

                // Thanks: https://neosmart.net/wiki/mbr-boot-process/
                // On any IBM-compatible PCs, the final two bytes of the
                // 512-byte MBR are called boot signature and are used by the
                // bios to determine if the boot drive (image on this case)
                // is actually bootable or not.

                // Fun fact: sometimes, a bootable disk will just display a
                // "This disk is not bootable..." when booted.
                // TODO: Detect those kind of disk
                file.Seek(510, SeekOrigin.Begin);

                // seek the 510th byte and check if 0x55 and 0xAA is present
                bool isBootable = file.Length >= 512 && (file.ReadByte() == 0x55 && file.ReadByte() == 0xAA);

                PrintBootableLine(path, isBootable);
                file.Close();
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey(false);
            Console.WriteLine(""); // Just in case
        }

        /// <summary>
        /// Write if can be possible to boot the specific file.
        /// </summary>
        /// <param name="path">Filename to print</param>
        /// <param name="isBootable">Is it bootable?</param>
        private static void PrintBootableLine(string path, bool isBootable)
        {
            if (isBootable)
            {
                // Colors make everyting more readable!
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[ Bootable ]");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("[Unbootable]");
            }

            Console.ResetColor();
            Console.WriteLine(" {0}", Path.GetFileName(path));
        }
    }
}