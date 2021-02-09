module Main where

import Lib
import Text.Regex.TDFA

unwrapResult (Left x) = do
    print x
    return []
unwrapResult (Right x) =
    return x

fields = ["byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"]

validField ("byr", value) = value =~ "\\`[0-9]{4}\\'" && let byr = (read value) in 1920 <= byr && byr <= 2002
validField ("iyr", value) = value =~ "\\`[0-9]{4}\\'" && let iyr = (read value) in 2010 <= iyr && iyr <= 2020
validField ("eyr", value) = value =~ "\\`[0-9]{4}\\'" && let eyr = (read value) in 2020 <= eyr && eyr <= 2030
validField ("hgt", value) = (value =~ "\\`[0-9]+cm\\'" && let hgt = (read (take ((length value) - 2) value)) in 150 <= hgt && hgt <= 193)
                         || (value =~ "\\`[0-9]+in\\'" && let hgt = (read (take ((length value) - 2) value)) in 59 <= hgt && hgt <= 76)
validField ("hcl", value) = (value =~ "\\`#[0-9a-f]{6}\\'")
validField ("ecl", value) = (value =~ "\\`(amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)\\'")
validField ("pid", value) = (value =~ "\\`[0-9]{9}\\'")
validField ("cid", value) = True
validField (x, value)     = False

necessaryFields passports =
    filter (\x -> all (\field -> any (\(x, y) -> x == field) x) fields) passports

main :: IO ()
main = do
    print $ validField ("ecl", "amb")
    input <- readFile "input"
    putStrLn "--- Part One ---\n"
    result <- unwrapResult $ parseInput input
    let validOne = length $ necessaryFields result
    print validOne
    putStrLn "\n--- Part Two ---\n"
    let validTwo = length $ filter (\x -> all validField x) $ necessaryFields result
    print validTwo
