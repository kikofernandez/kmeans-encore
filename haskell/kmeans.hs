type Pair a b = (a, b)
data Centroid a = Centroid { color :: a,
                             point :: Pair a a
                           }

instance Eq (Centroid a) where
  (==) x y = True

points = undefined --[(1,1), (2,2), (3,3)]

euclidianDistance :: (Floating b, Integral a) => Pair a a -> Pair a a -> b
euclidianDistance (x1, x2) (y1, y2) =  sqrt . fromIntegral $ ((x1-y1)^2) + ((x2-y2)^2)

getCentroids :: [Centroid a]
getCentroids = undefined

assignPointToCentroid :: Num a => [Centroid a] -> (a, a) -> (a, (a, a))
assignPointToCentroid = undefined

updateCentroid :: Num a => [Centroid a] -> [Centroid a]
updateCentroid = undefined

mergePoints :: Num a => [(a, (a, a))] -> [(a, [Pair a a])]
mergePoints = undefined

runKmeans :: Num a => [Centroid a] -> [(a, [Pair a a])]
runKmeans centroids =
  let points' = map (assignPointToCentroid centroids) points
      centroids' = updateCentroid centroids in
  if centroids == centroids' then runKmeans centroids'
  else mergePoints points'


kmeans :: Num a => [(a, [Pair a a])]
kmeans = runKmeans getCentroids

main = undefined
