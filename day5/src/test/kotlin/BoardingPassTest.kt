import kotlin.test.Test
import kotlin.test.assertEquals

class BoardingPassTest {
    @Test
    fun createBoardingPass() {
        assertEquals(BoardingPass(44, 5), newBoardingPass("FBFBBFFRLR"))
    }
}