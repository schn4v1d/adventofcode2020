def slope(xstep, ystep, lines, width):
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
    width = len(lines[0])
    part_one = slope(3, 1, lines, width)
    print(f"--- Part One ---\n\nTrees: {part_one}\n")
    part_two = slope(1, 1, lines, width) * slope(3, 1, lines, width) * slope(5, 1, lines, width) * slope(7, 1, lines, width) * slope(1, 2, lines, width)
    print(f"--- Part Two ---\n\nTrees: {part_two}\n")

if __name__ == "__main__":
    main()