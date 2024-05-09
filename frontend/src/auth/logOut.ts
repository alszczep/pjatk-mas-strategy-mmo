import { authTokenKey } from "."

export const logOut = async () => {
  // TODO: backend
  localStorage.removeItem(authTokenKey)
}
