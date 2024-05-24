import { apiFetch } from "./apiFetch"

type VillageDTO = {
  name: string
}

type TokenDTO = {
  token: string
}

export const loginEndpoint = (
  username: string,
  password: string,
): Promise<TokenDTO> => apiFetch("user/login", "POST", { username, password })

export const registerEndpoint = (
  username: string,
  password: string,
): Promise<TokenDTO> =>
  apiFetch("user/register", "POST", { username, password })

export const ownerVillageEndpoint = (): Promise<VillageDTO> =>
  apiFetch("village/byOwner", "GET")

export const villageByIdEndpoint = (id: string): Promise<VillageDTO> =>
  apiFetch(`village/byVillageId/${id}`, "GET")
