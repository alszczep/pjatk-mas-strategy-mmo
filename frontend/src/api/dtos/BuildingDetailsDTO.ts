import { type ResourcesDTO } from "./common"

export type BuildingDetailsDTO = {
  id: string
  name: string
  imageUrl: string
  currentLevel: number
  upgrade?: UpgradeDTO
  resourcesProductionPerMinute?: ResourcesDTO
  trainableUnits?: TrainableUnitDTO[]
}

export type TrainableUnitDTO = {
  id: string
  name: string
  trainingTimeInSeconds: number
  trainingCost: ResourcesDTO
  iconUrl?: string
}

export type BuildingDetailsParametersDTO = {
  buildingSpot: number
  villageId: string
}

export type UpgradeDTO = {
  upgradeableToLevel: number
  buildingTimeInSeconds: number
  upgradeCost: ResourcesDTO
}
