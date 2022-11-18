using System;
using System.Collections.Generic;
using System.Linq;

namespace Insert_Delete_GetRandom_O_1____Duplicates_allowed
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }


  public class RandomizedCollection
  {
    Dictionary<int, HashSet<int>> hash;
    List<int> items;
    Random random;
    public RandomizedCollection()
    {
      hash = new Dictionary<int, HashSet<int>>();
      items = new List<int>();
      random = new Random();
    }

    public bool Insert(int val)
    {
      var present = hash.ContainsKey(val);
      items.Add(val);
      if (!present)
      {
        hash.Add(val, new HashSet<int>());
      }
      hash[val].Add(items.Count - 1);
      return !present;
    }

    public bool Remove(int val)
    {
      if (!hash.ContainsKey(val)) return false;
      var removeIndex = hash[val].First();
      // remove the val from the hash, as anyway we have to remove this item entry
      // we will be replacing the last item from items into the current position where val is found
      hash[val].Remove(removeIndex);
      if(removeIndex != items.Count - 1)
      {
        // last item in items will be swapped to a different position, so remove index of last items from the hash
        hash[items[^1]].Remove(items.Count - 1);
        // add the new index where last item will be placed
        hash[items[^1]].Add(removeIndex);
        // update items current position with the items last no.
        items[removeIndex] = items[^1];
      }
      // remove the last item from items
      items.RemoveAt(items.Count - 1);
      // at any time hash key count is 0, remvoe the key
      if (hash[val].Count == 0) hash.Remove(val);
      return true;
    }

    public int GetRandom()
    {
      var index = random.Next(0, items.Count);
      return items[index];
    }
  }

  /**
   * Your RandomizedCollection object will be instantiated and called as such:
   * RandomizedCollection obj = new RandomizedCollection();
   * bool param_1 = obj.Insert(val);
   * bool param_2 = obj.Remove(val);
   * int param_3 = obj.GetRandom();
   */
}
