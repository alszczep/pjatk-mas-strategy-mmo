import { authTokenKey } from "."

export const logIn = async (username: string, password: string) => {
  // TODO: backend
  const token = `${username}/${password}`
  localStorage.setItem(authTokenKey, token)
}
