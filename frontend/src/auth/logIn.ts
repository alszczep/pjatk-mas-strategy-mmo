import { authTokenKey } from "."
import { loginEndpoint } from "../api/endpoints"
import { router, routes } from "../routes"

export const logIn = async (username: string, password: string) => {
  const token = await loginEndpoint(username, password)
  localStorage.setItem(authTokenKey, token.token)
  router.push(routes.village)
}
