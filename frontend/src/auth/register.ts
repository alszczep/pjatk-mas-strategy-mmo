import { authTokenKey } from "."
import { registerEndpoint, villageIdByOwnerEndpoint } from "../api/endpoints"
import { router, routes } from "../routes"

export const register = async (username: string, password: string) => {
  const token = await registerEndpoint(username, password)
  localStorage.setItem(authTokenKey, token.token)
  const villageId = await villageIdByOwnerEndpoint()
  router.push(routes.game.village.withParam(villageId))
}
