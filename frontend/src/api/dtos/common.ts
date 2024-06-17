export type ResourcesDTO = {
  wood: number
  iron: number
  wheat: number
  gold: number
}

export type ResultOrError<T = boolean> = {
  result?: T
  error?: string
}
