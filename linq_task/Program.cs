using System;
using System.Collections.Generic;

public static class MyLinq
{
    // ---------------- Filtering ----------------
    public static List<T> MyWhere<T>(this List<T> source, Func<T, bool> predicate)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
                result.Add(source[i]);
        }
        return result;
    }
    public static List<T> MyIndexedWhere<T>(this List<T> source, Func<T, int, bool> predicate)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < source.Count; i++)
        {
            if (predicate(source[i], i))
                result.Add(source[i]);
        }
        return result;
    }

    // ---------------- Transformation ----------------
    public static List<TResult> MySelect<T, TResult>(this List<T> source, Func<T, TResult> selector)
    {
        List<TResult> result = new List<TResult>();
        for (int i = 0; i < source.Count; i++)
        {
            result.Add(selector(source[i]));
        }
        return result;
    }

    public static List<TResult> MySelectIndex<T, TResult>(this List<T> source, Func<T, int, TResult> selector)
    {
        List<TResult> result = new List<TResult>();
        for (int i = 0; i < source.Count; i++)
        {
            result.Add(selector(source[i], i));
        }
        return result;
    }

    public static List<TResult> MySelectMany<TSource, TResult>(
        this List<TSource> source,
        Func<TSource, IEnumerable<TResult>> selector)
    {
        List<TResult> result = new List<TResult>();
        foreach (var item in source)
        {
            foreach (var subItem in selector(item))
            {
                result.Add(subItem);
            }
        }
        return result;
    }

    // ---------------- Partitioning ----------------
    public static List<T> MySkip<T>(this List<T> source, int count)
    {
        List<T> result = new List<T>();
        for (int i = count; i < source.Count; i++)
        {
            result.Add(source[i]);
        }
        return result;
    }

    public static List<T> MyTake<T>(this List<T> source, int count)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < source.Count && i < count; i++)
        {
            result.Add(source[i]);
        }
        return result;
    }

    public static List<T> MyTakeLast<T>(this List<T> source, int count)
    {
        List<T> result = new List<T>();
        int start = Math.Max(0, source.Count - count);
        for (int i = start; i < source.Count; i++)
        {
            result.Add(source[i]);
        }
        return result;
    }

    public static List<T> MySkipLast<T>(this List<T> source, int count)
    {
        List<T> result = new List<T>();
        int end = Math.Max(0, source.Count - count);
        for (int i = 0; i < end; i++)
        {
            result.Add(source[i]);
        }
        return result;
    }

    public static List<T> MyTakeWhile<T>(this List<T> source, Func<T, bool> predicate)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < source.Count; i++)
        {
            if (predicate(source[i])) result.Add(source[i]);
            else break;
        }
        return result;
    }

    public static List<T> MySkipWhile<T>(this List<T> source, Func<T, bool> predicate)
    {
        List<T> result = new List<T>();
        bool skipDone = false;
        for (int i = 0; i < source.Count; i++)
        {
            if (!skipDone && predicate(source[i]))
                continue;
            skipDone = true;
            result.Add(source[i]);
        }
        return result;
    }

    public static List<List<T>> MyChunk<T>(this List<T> source, int size)
    {
        if (size <= 0) throw new ArgumentException("Size must be > 0");
        List<List<T>> result = new List<List<T>>();
        for (int i = 0; i < source.Count; i += size)
        {
            List<T> chunk = new List<T>();
            for (int j = i; j < i + size && j < source.Count; j++)
            {
                chunk.Add(source[j]);
            }
            result.Add(chunk);
        }
        return result;
    }

    // ---------------- Ordering ----------------
    public static List<T> MyOrderBy<T, TKey>(this List<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
    {
        List<T> result = new List<T>(source);
        for (int i = 0; i < result.Count; i++)
        {
            for (int j = i + 1; j < result.Count; j++)
            {
                if (keySelector(result[i]).CompareTo(keySelector(result[j])) > 0)
                {
                    T temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }
        return result;
    }

    public static List<T> MyOrderByDescending<T, TKey>(this List<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
    {
        List<T> result = new List<T>(source);
        for (int i = 0; i < result.Count; i++)
        {
            for (int j = i + 1; j < result.Count; j++)
            {
                if (keySelector(result[i]).CompareTo(keySelector(result[j])) < 0)
                {
                    T temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }
        return result;
    }

    // ---------------- Single Element ----------------
    public static T MyFirst<T>(this List<T> source)
    {
        if (source.Count == 0) throw new Exception("Empty");
        return source[0];
    }

    public static T MyFirstOrDefault<T>(this List<T> source)
    {
        return source.Count > 0 ? source[0] : default(T);
    }

    public static T MyLast<T>(this List<T> source)
    {
        if (source.Count == 0) throw new Exception("Empty");
        return source[source.Count - 1];
    }

    public static T MyLastOrDefault<T>(this List<T> source)
    {
        return source.Count > 0 ? source[source.Count - 1] : default(T);
    }

    public static T MySingle<T>(this List<T> source)
    {
        if (source.Count != 1) throw new Exception("Not single");
        return source[0];
    }

    public static T MySingleOrDefault<T>(this List<T> source)
    {
        if (source.Count > 1) throw new Exception("More than one");
        return source.Count == 1 ? source[0] : default(T);
    }

    // ---------------- Distinct ----------------
    public static List<T> MyDistinct<T>(this List<T> source)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < source.Count; i++)
        {
            if (!result.Contains(source[i]))
                result.Add(source[i]);
        }
        return result;
    }

    public static List<TSource> MyDistinctBy<TSource, TKey>(
        this List<TSource> source,
        Func<TSource, TKey> keySelector)
    {
        List<TSource> result = new List<TSource>();
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        foreach (var item in source)
        {
            if (seenKeys.Add(keySelector(item)))
            {
                result.Add(item);
            }
        }
        return result;
    }

    // ---------------- Aggregates ----------------
    public static int MyCount<T>(this List<T> source)
    {
        int c = 0;
        for (int i = 0; i < source.Count; i++) c++;
        return c;
    }

    public static int MySum(this List<int> source)
    {
        int sum = 0;
        for (int i = 0; i < source.Count; i++) sum += source[i];
        return sum;
    }

    public static double MyAverage(this List<int> source)
    {
        if (source.Count == 0) throw new Exception("Empty");
        int sum = 0;
        for (int i = 0; i < source.Count; i++) sum += source[i];
        return (double)sum / source.Count;
    }

    public static T MyMax<T>(this List<T> source) where T : IComparable<T>
    {
        if (source.Count == 0) throw new Exception("Empty");
        T max = source[0];
        for (int i = 1; i < source.Count; i++)
        {
            if (source[i].CompareTo(max) > 0) max = source[i];
        }
        return max;
    }

    public static T MyMin<T>(this List<T> source) where T : IComparable<T>
    {
        if (source.Count == 0) throw new Exception("Empty");
        T min = source[0];
        for (int i = 1; i < source.Count; i++)
        {
            if (source[i].CompareTo(min) < 0) min = source[i];
        }
        return min;
    }

    public static TSource MyMaxBy<TSource, TKey>(
        this List<TSource> source,
        Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
    {
        if (source.Count == 0) throw new Exception("Empty");
        TSource maxItem = source[0];
        TKey maxKey = keySelector(maxItem);
        for (int i = 1; i < source.Count; i++)
        {
            TKey currentKey = keySelector(source[i]);
            if (currentKey.CompareTo(maxKey) > 0)
            {
                maxKey = currentKey;
                maxItem = source[i];
            }
        }
        return maxItem;
    }

    public static TSource MyMinBy<TSource, TKey>(
        this List<TSource> source,
        Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
    {
        if (source.Count == 0) throw new Exception("Empty");
        TSource minItem = source[0];
        TKey minKey = keySelector(minItem);
        for (int i = 1; i < source.Count; i++)
        {
            TKey currentKey = keySelector(source[i]);
            if (currentKey.CompareTo(minKey) < 0)
            {
                minKey = currentKey;
                minItem = source[i];
            }
        }
        return minItem;
    }

    // ---------------- Casting ----------------
    public static T[] MyToArray<T>(this List<T> source)
    {
        T[] arr = new T[source.Count];
        for (int i = 0; i < source.Count; i++) arr[i] = source[i];
        return arr;
    }

    public static List<T> MyToList<T>(this List<T> source)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < source.Count; i++) result.Add(source[i]);
        return result;
    }

    public static Dictionary<TKey, TSource> MyToDictionary<TSource, TKey>(
        this List<TSource> source,
        Func<TSource, TKey> keySelector)
    {
        Dictionary<TKey, TSource> dict = new Dictionary<TKey, TSource>();
        foreach (var item in source)
        {
            dict[keySelector(item)] = item; // last one wins
        }
        return dict;
    }

    public static HashSet<T> MyToHashSet<T>(this List<T> source)
    {
        HashSet<T> set = new HashSet<T>();
        foreach (var item in source)
        {
            set.Add(item);
        }
        return set;
    }

    // ---------------- Set Operations ----------------
    public static List<T> MyUnion<T>(this List<T> first, List<T> second)
    {
        List<T> result = new List<T>(first);
        for (int i = 0; i < second.Count; i++)
        {
            if (!result.Contains(second[i]))
                result.Add(second[i]);
        }
        return result;
    }

    public static List<T> MyIntersect<T>(this List<T> first, List<T> second)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < first.Count; i++)
        {
            if (second.Contains(first[i]) && !result.Contains(first[i]))
                result.Add(first[i]);
        }
        return result;
    }

    public static List<T> MyExcept<T>(this List<T> first, List<T> second)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < first.Count; i++)
        {
            if (!second.Contains(first[i]))
                result.Add(first[i]);
        }
        return result;
    }

    public static List<T> MyConcat<T>(this List<T> first, List<T> second)
    {
        List<T> result = new List<T>(first);
        for (int i = 0; i < second.Count; i++)
        {
            result.Add(second[i]);
        }
        return result;
    }

    public static List<TSource> MyUnionBy<TSource, TKey>(
        this List<TSource> first,
        List<TSource> second,
        Func<TSource, TKey> keySelector)
    {
        List<TSource> result = new List<TSource>();
        HashSet<TKey> seenKeys = new HashSet<TKey>();

        foreach (var item in first)
        {
            if (seenKeys.Add(keySelector(item)))
                result.Add(item);
        }
        foreach (var item in second)
        {
            if (seenKeys.Add(keySelector(item)))
                result.Add(item);
        }
        return result;
    }

    // ---------------- Quantifiers ----------------
    public static bool MyAny<T>(this List<T> source, Func<T, bool> predicate)
    {
        for (int i = 0; i < source.Count; i++)
        {
            if (predicate(source[i])) return true;
        }
        return false;
    }

    public static bool MyAll<T>(this List<T> source, Func<T, bool> predicate)
    {
        for (int i = 0; i < source.Count; i++)
        {
            if (!predicate(source[i])) return false;
        }
        return true;
    }

    public static bool MyContains<T>(this List<T> source, T value)
    {
        for (int i = 0; i < source.Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(source[i], value))
                return true;
        }
        return false;
    }

    // ---------------- Element Access ----------------
    public static T MyElementAt<T>(this List<T> source, int index)
    {
        if (index < 0 || index >= source.Count) throw new Exception("Out of range");
        return source[index];
    }

    public static T MyElementAtOrDefault<T>(this List<T> source, int index)
    {
        if (index < 0 || index >= source.Count) return default(T);
        return source[index];
    }

    // ---------------- Joining ----------------
    public static List<TResult> MyJoin<TOuter, TInner, TKey, TResult>(
        this List<TOuter> outer,
        List<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector)
    {
        List<TResult> result = new List<TResult>();
        for (int i = 0; i < outer.Count; i++)
        {
            for (int j = 0; j < inner.Count; j++)
            {
                if (EqualityComparer<TKey>.Default.Equals(
                    outerKeySelector(outer[i]),
                    innerKeySelector(inner[j])))
                {
                    result.Add(resultSelector(outer[i], inner[j]));
                }
            }
        }
        return result;
    }

    // ---------------- Reverse ----------------
    public static List<T> MyReverse<T>(this List<T> source)
    {
        List<T> result = new List<T>();
        for (int i = source.Count - 1; i >= 0; i--)
        {
            result.Add(source[i]);
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        // Sample data
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<string> words = new List<string> { "apple", "banana", "cherry", "apple", "banana" };
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Marks = 90, Subjects = new List<string> { "Math", "Physics" } },
            new Student { Id = 2, Name = "Bob", Marks = 75, Subjects = new List<string> { "Chemistry", "Biology" } },
            new Student { Id = 3, Name = "Charlie", Marks = 85, Subjects = new List<string> { "Math", "Biology" } }
        };

        Console.WriteLine("----- Filtering -----");
        Console.WriteLine(string.Join(", ", numbers.MyWhere(n => n > 5)));
        Console.WriteLine(string.Join(", ", numbers.MyIndexedWhere((n, i) => i % 2 == 0)));

        Console.WriteLine("\n----- Transformation -----");
        Console.WriteLine(string.Join(", ", numbers.MySelect(n => n * n)));
        Console.WriteLine(string.Join(", ", words.MySelectIndex((w, i) => $"{i}:{w}")));
        Console.WriteLine(string.Join(", ", students.MySelectMany(s => s.Subjects)));

        Console.WriteLine("\n----- Partitioning -----");
        Console.WriteLine(string.Join(", ", numbers.MySkip(5)));
        Console.WriteLine(string.Join(", ", numbers.MyTake(3)));
        Console.WriteLine(string.Join(", ", numbers.MyTakeLast(3)));
        Console.WriteLine(string.Join(", ", numbers.MySkipLast(3)));
        Console.WriteLine(string.Join(", ", numbers.MyTakeWhile(n => n < 6)));
        Console.WriteLine(string.Join(", ", numbers.MySkipWhile(n => n < 6)));
        foreach (var chunk in numbers.MyChunk(3))
            Console.WriteLine($"[{string.Join(", ", chunk)}]");

        Console.WriteLine("\n----- Ordering -----");
        Console.WriteLine(string.Join(", ", numbers.MyOrderBy(n => n)));
        Console.WriteLine(string.Join(", ", numbers.MyOrderByDescending(n => n)));

        Console.WriteLine("\n----- Single Element -----");
        Console.WriteLine(numbers.MyFirst());
        Console.WriteLine(numbers.MyFirstOrDefault());
        Console.WriteLine(numbers.MyLast());
        Console.WriteLine(numbers.MyLastOrDefault());
        Console.WriteLine(new List<int> { 42 }.MySingle());
        Console.WriteLine(new List<int> { 42 }.MySingleOrDefault());

        Console.WriteLine("\n----- Distinct -----");
        Console.WriteLine(string.Join(", ", words.MyDistinct()));
        Console.WriteLine(string.Join(", ", students.MyDistinctBy(s => s.Id).MySelect(s => s.Name)));

        Console.WriteLine("\n----- Aggregates -----");
        Console.WriteLine(numbers.MyCount());
        Console.WriteLine(numbers.MySum());
        Console.WriteLine(numbers.MyAverage());
        Console.WriteLine(numbers.MyMax());
        Console.WriteLine(numbers.MyMin());
        Console.WriteLine(students.MyMaxBy(s => s.Marks).Name);
        Console.WriteLine(students.MyMinBy(s => s.Marks).Name);

        Console.WriteLine("\n----- Casting -----");
        Console.WriteLine(string.Join(", ", numbers.MyToArray()));
        Console.WriteLine(string.Join(", ", numbers.MyToList()));
        var dict = students.MyToDictionary(s => s.Id);
        foreach (var kv in dict) Console.WriteLine($"{kv.Key}:{kv.Value.Name}");
        var set = words.MyToHashSet();
        Console.WriteLine(string.Join(", ", set));

        Console.WriteLine("\n----- Set Operations -----");
        var nums1 = new List<int> { 1, 2, 3, 4 };
        var nums2 = new List<int> { 3, 4, 5, 6 };
        Console.WriteLine(string.Join(", ", nums1.MyUnion(nums2)));
        Console.WriteLine(string.Join(", ", nums1.MyIntersect(nums2)));
        Console.WriteLine(string.Join(", ", nums1.MyExcept(nums2)));
        Console.WriteLine(string.Join(", ", nums1.MyConcat(nums2)));
        Console.WriteLine(string.Join(", ", students.MyUnionBy(
            new List<Student> { new Student { Id = 2, Name = "Duplicate", Marks = 70 } },
            s => s.Id).MySelect(s => s.Name)));

        Console.WriteLine("\n----- Quantifiers -----");
        Console.WriteLine(numbers.MyAny(n => n > 9));
        Console.WriteLine(numbers.MyAll(n => n > 0));
        Console.WriteLine(words.MyContains("banana"));

        Console.WriteLine("\n----- Element Access -----");
        Console.WriteLine(numbers.MyElementAt(2));
        Console.WriteLine(numbers.MyElementAtOrDefault(100)); // default = 0

        Console.WriteLine("\n----- Joining -----");
        var courses = new List<Course>
        {
            new Course { StudentId = 1, Title = "C#" },
            new Course { StudentId = 2, Title = "Java" },
            new Course { StudentId = 3, Title = "Python" }
        };
        var joinResult = students.MyJoin(
            courses,
            s => s.Id,
            c => c.StudentId,
            (s, c) => $"{s.Name} enrolled in {c.Title}");
        Console.WriteLine(string.Join(" | ", joinResult));

        Console.WriteLine("\n----- Reverse -----");
        Console.WriteLine(string.Join(", ", numbers.MyReverse()));
    }
}

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
    public List<string> Subjects { get; set; }
}

class Course
{
    public int StudentId { get; set; }
    public string Title { get; set; }
}
