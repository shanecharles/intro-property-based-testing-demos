module Addition where

import Test.Hspec
import Test.QuickCheck


prop_AddIsCommutative :: Int -> Int -> Bool
prop_AddIsCommutative x y =
  x + y == y + x


prop_AddIsAssociative :: (Int, Int, Int) -> Bool
prop_AddIsAssociative (x, y, z) =
  (x +  y) + z == x + (y + z)

  
prop_SumOfTwoNumbersIsGreaterThanOrEqualToXorY :: (Int, Int) -> Bool
prop_SumOfTwoNumbersIsGreaterThanOrEqualToXorY (x, y) =
  any (\z -> z <= x + y) [x, y]


main :: IO ()
main = hspec $ do
  describe "Addition" $ do
    it "is commutative" $ do
      property $ prop_AddIsCommutative
    it "is associative" $ do
      property $ prop_AddIsAssociative
    it "of x and y has a result greater than or equal to x or y" $ do
      property $ prop_SumOfTwoNumbersIsGreaterThanOrEqualToXorY
