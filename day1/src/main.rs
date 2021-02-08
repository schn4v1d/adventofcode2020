use itertools::Itertools;
use rayon::iter::{IntoParallelRefIterator, ParallelIterator};
use std::io::Read;

fn main() -> Result<(), std::io::Error> {
    let mut input = std::fs::File::open("input/input")?;
    let mut buffer = String::new();

    input.read_to_string(&mut buffer)?;

    let numbers: Vec<u32> = buffer.lines().map(|x| x.parse::<u32>().unwrap()).collect();

    let result = numbers
        .par_iter()
        .copied()
        .map(|x| {
            numbers
                .par_iter()
                .copied()
                .find_any(|y| x + y == 2020)
                .map(|y| x * y)
        })
        .find_first(|x| x.is_some())
        .map(Option::unwrap)
        .unwrap();

    println!("--- Part One ---\n\n    The result is: {}\n", result);

    let result = numbers
        .iter()
        .permutations(3)
        .find(|x| x[0] + x[1] + x[2] == 2020)
        .map(|x| x[0] * x[1] * x[2])
        .unwrap();

    println!("--- Part Two ---\n\n    The result is: {}\n", result);

    Ok(())
}
