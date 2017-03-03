using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindFile
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введи что ты ищешь?(text.txt, *.zip, ?.???)");
			string file = Console.ReadLine();
			Console.WriteLine(@"Введи где искать?(C:\Users\q\Desktop\book\)");
			string address = Console.ReadLine();
			uint i = 0;
			Console.WriteLine("Результаты:");
			foreach (FileInfo f in FindFile(address, file))
			{
				Console.Write(i++.ToString() + ".\t");
				Console.WriteLine(f.FullName);
			}
			if (i == 0)
				Console.WriteLine("Файлы не найдены!");

		}
		static FileInfo[] FindFile(string address, string filename)
		{
			DirectoryInfo dir = new DirectoryInfo(address);
			FileInfo[] file_inf = null;
			if (dir.Exists)
			{
				file_inf = dir.GetFiles(filename);

				foreach (DirectoryInfo subdir in dir.GetDirectories())
					__FindFile(subdir, filename, ref file_inf);
			}
			return file_inf;
		}
		static void __FindFile(DirectoryInfo dir, string filename, ref FileInfo[] file_inf)
		{
			if (dir.Exists)
			{
				FileInfo[] file_inf2 = dir.GetFiles(filename);
				file_inf = file_inf.Concat(file_inf2).ToArray();

				foreach (DirectoryInfo subdir in dir.GetDirectories())
					__FindFile(subdir, filename, ref file_inf);
			}
		}
	}
}
