namespace MachineLearning

module KMeans =
  type Point<'a> = 'a * 'a

  let private max_rnd_number = 100

  let pointFactory number_points =
    let rnd = System.Random()
    List.init number_points (fun _ -> (rnd.Next(max_rnd_number), rnd.Next(max_rnd_number)))

  let distance (x1,x2) (y1,y2) =
    (pown (x1-y1) 2) + (pown (x2-y2) 2) |> float |> sqrt |> int

  let private toDict (m: Map<int, int Point list>)  (k:int, v: int * int) =
    let m' = Map.containsKey k m
    if m' then
      let l = Map.find k m
      Map.add k (v::l) m
    else
      Map.add k [v] m

  let createCluster centroids dataset =
    dataset
    |> List.map (fun point ->
                 List.mapi (fun i c -> (i, distance c point, point)) centroids
                 |> List.minBy (fun (_, x, _) -> x)
                 |> (fun (i, _, point) -> (i, point)))
    |> List.fold toDict Map.empty

  let chooseCentroid ((k:int), v: int Point list) =
    let size = v.Length
    let (x, y) = List.reduce (fun (acc1, acc2) (x, y) -> acc1+x, acc2+y) v
    int(x/size), int(y/size)

  let updateCentroids initialCentroids dataset =
    let rec updateCentroids' initialCentroids =
      let existsInInitial n = List.exists (fun initElem -> n = initElem) initialCentroids
      let isSame l = List.forall (fun n -> existsInInitial n) l
      let nextCentroids = createCluster initialCentroids dataset
                          |> Map.toList
                          |> List.map chooseCentroid

      let changed = not (isSame nextCentroids)
      if not changed then
        nextCentroids
      else
        updateCentroids' nextCentroids

    updateCentroids' initialCentroids

  let start k npoints =
    let dataset = pointFactory npoints
    let initialCentroids = pointFactory k
    (updateCentroids initialCentroids dataset, dataset)

  // allows you to start with a given dataset
  // let start2 k dataset =
  //   let initialCentroids = selectCentroids k dataset
  //   (updateCentroids initialCentroids dataset, dataset)
