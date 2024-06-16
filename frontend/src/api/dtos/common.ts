export type ResourcesDTO = {
  wood: number
  iron: number
  wheat: number
  gold: number
}

export type ResultOrError<T> = {
  result?: T
  error?: string
}
