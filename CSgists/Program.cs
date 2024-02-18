
using CSgists;

var a = "abcd".ToCharArray();
for (int i = 0; i < 24; i++)
{
	var b = PermutationWithIndex.GetCloned(a, i);
    Console.WriteLine(new string(b));
}