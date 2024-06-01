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

export type BuildableBuildingDTO = {
  id: string
  name: string
  imageUrl: string
  cost: ResourceDTO
}

export type BuildingDetailsDTO = {
  id: string
  name: string
  imageUrl: string
  place: number
  level: number
  upgradeCost: ResourceDTO
  production?: ResourceDTO
  trainableTroops?: TroopDTO[]
}

type TroopDTO = {
  id: string
  name: string
  imageUrl: string
  unitCost: ResourceDTO
  minBarracksLevel: number
}
