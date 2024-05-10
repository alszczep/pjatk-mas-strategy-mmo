import { authTokenKey } from "."
import { router, routes } from "../routes"

export const logOut = async () => {
  // TODO: backend
  localStorage.removeItem(authTokenKey)
  router.push(routes.login)
}
