def slope(xstep, ystep, lines, width):
    width = len(lines[0])
    trees = 0
    for y in range(0, len(lines), ystep):
        x = (y // ystep) * xstep
        if lines[y][x % width] == '#':
            trees += 1
    return trees

def main():
    input = open("input")
    lines = list(map(lambda a: a.strip(), input.readlines()))
    input.close()
    part_one = slope(3, 1, lines)
    print(f"--- Part One ---\n\nTrees: {part_one}\n")
    part_two = slope(1, 1, lines)\
             * slope(3, 1, lines)\
             * slope(5, 1, lines)\
             * slope(7, 1, lines)\
             * slope(1, 2, lines)
    print(f"--- Part Two ---\n\nTrees: {part_two}\n")

if __name__ == "__main__":
    main()