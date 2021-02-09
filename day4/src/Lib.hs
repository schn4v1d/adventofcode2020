module Lib
    ( passports
    , parseInput
    ) where

import Text.Megaparsec
import Text.Megaparsec.Char
import Data.Void
import Data.Char

type Parser = Parsec Void String

entry :: Parser (String, String)
entry = do
    label <- some $ satisfy (\x -> (isAlphaNum x) || x == '#')
    char ':'
    value <- some $ satisfy (\x -> (isAlphaNum x) || x == '#')
    (oneOf " \n" >> return ()) <|> (eof)
    return (label, value)

passport :: Parser [(String, String)]
passport = some entry

passports :: Parser [[(String, String)]]
passports = sepBy1 passport (string "\n")

parseInput input = parse passports "input" input