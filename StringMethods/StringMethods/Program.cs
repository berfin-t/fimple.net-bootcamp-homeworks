string degisken = "Dersimiz CSharp, hoş geldiniz.";
string degisken2 = "CSharp";
// Length
Console.WriteLine(degisken.Length);

// ToUpper, ToLower
Console.WriteLine(degisken.ToUpper());
Console.WriteLine(degisken.ToLower());

// Concat
Console.WriteLine(String.Concat(degisken, " Merhaba!"));

// Compare, CompareTo

Console.WriteLine(degisken.CompareTo(degisken2)); //0,-1,1
Console.WriteLine(String.Compare(degisken, degisken2, true));
Console.WriteLine(String.Compare(degisken, degisken2, false));

// Contains
Console.WriteLine(degisken.Contains(degisken2));
Console.WriteLine(degisken.EndsWith("geldiniz."));
Console.WriteLine(degisken.StartsWith("dersimiz"));

//IndexOf
Console.WriteLine(degisken.IndexOf("CS"));
Console.WriteLine(degisken.IndexOf("Tansu"));
Console.WriteLine(degisken.LastIndexOf("i"));

// Insert
Console.WriteLine(degisken.Insert(0, "Merhaba! "));

//PadLeft, PadRight
Console.WriteLine(degisken + degisken2.PadLeft(30));
Console.WriteLine(degisken + degisken2.PadLeft(30, '*'));
Console.WriteLine(degisken.PadRight(50) + degisken2);
Console.WriteLine(degisken.PadRight(50, '-') + degisken2);

// Remove
Console.WriteLine(degisken.Remove(10));
Console.WriteLine(degisken.Remove(5, 3));
Console.WriteLine(degisken.Remove(0, 1));

// Replace
Console.WriteLine(degisken.Replace("CSharp", "C#"));
Console.WriteLine(degisken.Replace(" ", "*"));

// Split
Console.WriteLine(degisken.Split(' ')[1]);

// Substring
Console.WriteLine(degisken.Substring(4));
Console.WriteLine(degisken.Substring(4, 6));
