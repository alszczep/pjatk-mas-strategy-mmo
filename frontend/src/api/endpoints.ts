import { apiFetch } from "./apiFetch"
import type { BuildableBuildingDTO, BuildingDetailsDTO, TokenDTO } from "./dtos"
import type { VillageDetailsDTO } from "./dtos/VillageDetailsDTO"

export const loginEndpoint = (
  Username: string,
  Password: string,
): Promise<TokenDTO> => apiFetch("user/login", "POST", { Username, Password })

export const registerEndpoint = (
  Username: string,
  Password: string,
): Promise<TokenDTO> =>
  apiFetch("user/register", "POST", { Username, Password })

export const villageIdByOwnerEndpoint = (): Promise<string> =>
  apiFetch("village/villageIdByOwner", "GET")

export const villageByIdEndpoint = (
  villageId: string,
): Promise<VillageDetailsDTO> =>
  apiFetch(`village/byVillageId/${villageId}`, "GET")

export const getBuildableBuildingsEndpoint = (
  villageId: string,
): Promise<BuildableBuildingDTO[]> =>
  apiFetch(`building/buildableBuildings/${villageId}`, "GET")

export const getBuildingDetailsEndpoint = (
  VillageId: string,
  BuildingSpot: number,
): Promise<BuildingDetailsDTO | undefined> =>
  apiFetch("building/buildingDetails", "POST", { VillageId, BuildingSpot })
