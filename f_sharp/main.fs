open MachineLearning

[<EntryPoint>]
let main args =
  let centroids, _ = KMeans.start 5 10000
  printfn "%A" centroids
  0
