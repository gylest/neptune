using System;
using Xunit;
using learncsharp.Dev;

public class DataStructureTest
{
    [Fact]
    public void BinaryTree_Int_AddNodesAndTraverse()
    {
        // Arrange
        var tree = new BinaryTree<int>();
        tree.Insert(100); // Root

        // Add 8 random nodes
        int[] nodes = { 42, 150, 75, 120, 200, 60, 30, 110 };
        foreach (var n in nodes)
            tree.Insert(n);

        // Act & Assert
        // InOrderTraversal should print nodes in sorted order
        Console.WriteLine("InOrderTraversal (int):");
        tree.InOrderTraversal(tree.Root);

        // Lookup test
        Assert.True(tree.LookupRec(tree.Root, 150));
        Assert.False(tree.LookupRec(tree.Root, 999));
    }

    [Fact]
    public void BinaryTree_String_AddNodesAndTraverse()
    {
        // Arrange
        var tree = new BinaryTree<string>();
        tree.Insert("UK"); // Root

        // Add 8 country nodes
        string[] countries = { "Germany", "USA", "France", "Japan", "Italy", "Canada", "Australia", "Brazil" };
        foreach (var country in countries)
            tree.Insert(country);

        // Act & Assert
        Console.WriteLine("InOrderTraversal (string):");
        tree.InOrderTraversal(tree.Root);

        // Lookup test
        Assert.True(tree.LookupRec(tree.Root, "Germany"));
        Assert.False(tree.LookupRec(tree.Root, "Spain"));
    }
}