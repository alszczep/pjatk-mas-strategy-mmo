import { authTokenKey } from "."
import { router, routes } from "../routes"

export const logIn = async (username: string, password: string) => {
  // TODO: backend
  const token = `${username}/${password}`
  localStorage.setItem(authTokenKey, token)
  router.push(routes.village)
}
