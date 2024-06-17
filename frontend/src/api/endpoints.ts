import { apiFetch } from "./apiFetch"
import type { BuildableBuildingDTO } from "./dtos/BuildableBuildingDTO"
import type { BuildingDetailsDTO } from "./dtos/BuildingDetailsDTO"
import type { TokenDTO } from "./dtos/TokenDTO"
import type { VillageDetailsDTO } from "./dtos/VillageDetailsDTO"
import type { ResultOrError } from "./dtos/common"

export const loginEndpoint = (Username: string, Password: string) =>
  apiFetch<TokenDTO>("user/login", "POST", { Username, Password }, undefined, {
    noErrorToast: true,
  })

export const registerEndpoint = (Username: string, Password: string) =>
  apiFetch<TokenDTO>("user/register", "POST", { Username, Password })

export const villageIdByOwnerEndpoint = () =>
  apiFetch<string>("village/villageIdByOwner", "GET")

export const villageByIdEndpoint = (villageId: string) =>
  apiFetch<VillageDetailsDTO>(`village/byVillageId/${villageId}`, "GET")

export const getBuildableBuildingsEndpoint = (villageId: string) =>
  apiFetch<BuildableBuildingDTO[]>(
    `building/buildableBuildings/${villageId}`,
    "GET",
  )

export const getBuildingDetailsEndpoint = (
  VillageId: string,
  BuildingSpot: number,
) =>
  apiFetch<BuildingDetailsDTO | undefined>("building/buildingDetails", "POST", {
    VillageId,
    BuildingSpot,
  })

export const scheduleBuildingEndpoint = (
  VillageId: string,
  BuildingSpot: number,
  BuildingId: string,
) =>
  apiFetch("building/scheduleBuilding", "POST", {
    VillageId,
    BuildingSpot,
    BuildingId,
  })

export const scheduleUpgradeEndpoint = (
  VillageId: string,
  BuildingSpot: number,
) => apiFetch("building/scheduleUpgrade", "POST", { VillageId, BuildingSpot })

export const updateBuildingsQueueEndpoint = (villageId: string) =>
  apiFetch(`building/updateBuildingsQueue/${villageId}`, "POST")

export const scheduleMilitaryUnitTrainingEndpoint = (
  VillageId: string,
  MilitaryUnitId: string,
  Amount: number,
) =>
  apiFetch<ResultOrError<boolean>>(
    "militaryUnit/scheduleMilitaryUnitTraining",
    "POST",
    {
      VillageId,
      MilitaryUnitId,
      Amount,
    },
  )

export const updateMilitaryUnitsQueueEndpoint = (VillageId: string) =>
  apiFetch<ResultOrError<boolean>>(
    `militaryUnit/updateMilitaryUnitsQueue/${VillageId}`,
    "POST",
  )
