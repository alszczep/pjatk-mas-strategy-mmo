import type { ResourcesDTO } from "./common"

export type BuildableBuildingDTO = {
  id: string
  name: string
  imageUrl: string
  buildingTimeInSeconds: number
  cost: ResourcesDTO
}
