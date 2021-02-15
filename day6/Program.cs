using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var file = File.ReadAllLines("../../../input");
var groups = new List<List<char[]>>();
groups.Add(new List<char[]>());
foreach (var line in file) {
    if (line == "") {
        groups.Add(new List<char[]>());
        // Console.WriteLine("---");
    } else {
        var current = groups.Last();
        current.Add(line.ToCharArray());
        // Console.WriteLine(line);
    }
}

var partOne = groups.Select(
    group => {
        var questions = new List<char>();

        foreach (var question in from person in @group
            from question in person
            where !questions.Contains(question)
            select question) {
            questions.Add(question);
        }

        return questions.Count;
    }
).Sum();
Console.WriteLine($"--- Part One ---\n\n{partOne}");
var partTwo = groups.Select(
    group => {
        var questions = new List<char>();

        foreach (var question in from person in @group
            from question in person
            where !questions.Contains(question)
            select question) {
            questions.Add(question);
        }

        var toRemove = group
            .SelectMany(
                person =>
                    from question in questions
                    where !person.Contains(question)
                    select question
            ).Distinct().ToList();

        foreach (var question in toRemove) {
            questions.Remove(question);
        }

        return questions.Count;
    }
).Sum();
Console.WriteLine($"--- Part Two ---\n\n{partTwo}");