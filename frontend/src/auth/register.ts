import { authTokenKey } from "."
import { registerEndpoint } from "../api/endpoints"
import { router, routes } from "../routes"

export const register = async (username: string, password: string) => {
  const token = await registerEndpoint(username, password)
  localStorage.setItem(authTokenKey, token.token)
  router.push(routes.game.village.withParam(routes.game.village.paramDefault))
}
