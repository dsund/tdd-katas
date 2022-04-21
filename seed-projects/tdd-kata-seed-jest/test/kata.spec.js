import { TDD } from '../src/kata';

describe("TDD Kata", function () {
  it("should rocka fett", function() {
    // arrange
    let tdd = new TDD();
    // act
    let actual = tdd.kata;
    // assert
  	expect(actual).toBe("Rockar fett!");
  });
});