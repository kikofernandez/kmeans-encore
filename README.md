# k-means case study

Implementation of k-means clustering algorithm.

## Haskell

Implementation of k-means in Haskell to get a feel of it. We can compare on LOC,
complexity, etc.

## Encore

Implementation of k-means in Encore. There will be different implementations trying
to use different features of the language. Most interesting ones:

    * Points and Centroids are actors

    * Spawn tasks for calculating the Points using async-finish. Centroids are actors.

## Clojure

Implementation in Clojure using concurrency mechanism. It's of special interest the
use of CSP and transducers. Futures are interesting as well.

## C

There's an [open source C implementation](http://users.eecs.northwestern.edu/~wkliao/Kmeans/)
from a master student (Halil Bisain, Istanbul Technical University, Turkey). It has
a sequential implementation, an implementation using OpenMP and another one using MPI.
