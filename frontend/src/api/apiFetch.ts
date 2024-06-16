import { authTokenKey } from "../auth"
import { config } from "../config"

export const apiFetch = async (
  endpoint: string,
  method: "GET" | "POST" | "PUT" | "DELETE",
  body?: object,
  options?: RequestInit,
) => {
  const url = new URL(endpoint, config.apiBaseUrl)
  const response = await fetch(url, {
    body: body ? JSON.stringify(body) : undefined,
    method,
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem(authTokenKey)}`,
      credentials: "include",
      ...options?.headers,
    },
    ...options,
  })

  if (response.status === 204) {
    return undefined
  }

  return await response.json()
}
