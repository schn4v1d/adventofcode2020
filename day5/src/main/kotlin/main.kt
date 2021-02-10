import java.io.File

data class BoardingPass(val row: Int, val col: Int) {
    val id: Int
        get() = this.row * 8 + this.col
}

fun newBoardingPass(text: String): BoardingPass {
    var rowLower = 0
    var rowUpper = 128
    text.subSequence(0..6)
        .forEach { if (it == 'F') rowUpper = rowLower + (rowUpper - rowLower) / 2 else if (it == 'B') rowLower += (rowUpper - rowLower) / 2 }
    val row = rowLower

    var colLower = 0
    var colUpper = 8
    text.subSequence(7..9)
        .forEach { if (it == 'R') colLower += (colUpper - colLower) / 2 else if (it == 'L') colUpper = colLower + (colUpper - colLower) / 2 }
    val col = colLower

    return BoardingPass(row, col)
}

fun main(args: Array<String>) {
    val boardingPasses =
        File("input")
            .readLines()
            .map { newBoardingPass(it) }
            .sortedByDescending { it.id }

    println("--- Part One ---\n\nHighest Seat ID: ${boardingPasses[0].id}\n")

    var id = 0
    boardingPasses.map { it.id }.fold(boardingPasses[0].id, { acc, i -> if (acc == i + 2) id = i + 1; i })

    println("--- Part Two ---\n\nMy Seat ID: ${id}\n")
}