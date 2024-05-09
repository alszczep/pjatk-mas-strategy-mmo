import { authTokenKey } from "."

export const isLoggedIn = () => {
  return !!localStorage.getItem(authTokenKey)
}
