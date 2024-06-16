import { authTokenKey } from "."
import { loginEndpoint, villageIdByOwnerEndpoint } from "../api/endpoints"
import { router, routes } from "../routes"

export const logIn = async (username: string, password: string) => {
  const token = await loginEndpoint(username, password)
  localStorage.setItem(authTokenKey, token.token)
  const villageId = await villageIdByOwnerEndpoint()
  router.push(routes.game.village.withParam(villageId))
}
