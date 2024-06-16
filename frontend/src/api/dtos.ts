export type VillageDTO = {
  name: string
}

export type TokenDTO = {
  token: string
}

export type ResourceDTO = {
  wood: number
  iron: number
  wheat: number
  gold: number
}

export type BuildingSummaryDTO = {
  place: number
  level?: number
  imageUrl?: string
}

type TroopDTO = {
  id: string
  name: string
  imageUrl: string
  unitCost: ResourceDTO
  minBarracksLevel: number
}
