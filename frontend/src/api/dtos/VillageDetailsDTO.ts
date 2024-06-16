export type VillageDetailsDTO = {
  id: string
  name: string
  crestImageUrl?: string
  militaryUnits: VillageDetailsMilitaryUnitDTO[]
  buildings: VillageDetailsBuildingDTO[]
  availableResources: VillageDetailsResourcesDTO
  resourcesProductionPerMinute: VillageDetailsResourcesDTO
  militaryUnitsQueue: VillageDetailsMilitaryUnitQueueDTO[]
  buildingsQueue: VillageDetailsBuildingQueueDTO[]
}

export type VillageDetailsMilitaryUnitDTO = {
  id: string
  name: string
  amount: number
  iconUrl?: string
}

export type VillageDetailsBuildingDTO = {
  id: string
  name: string
  level: number
  imageUrl?: string
  buildingSpot: number
}

export type VillageDetailsResourcesDTO = {
  wood: number
  iron: number
  wheat: number
  gold: number
}

export type VillageDetailsMilitaryUnitQueueDTO = {
  id: string
  militaryUnitName: string
  amount: number
  startTime: string
  endTime: string
}

export type VillageDetailsBuildingQueueDTO = {
  id: string
  buildingName: string
  toLevel: number
  startTime: string
  endTime: string
}
