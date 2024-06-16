import { useToast } from "vue-toast-notification"
import { authTokenKey } from "../auth"
import { config } from "../config"

export const apiFetch = async <T = undefined>(
  endpoint: string,
  method: "GET" | "POST" | "PUT" | "DELETE",
  body?: object,
  options?: RequestInit,
): Promise<T> => {
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
    return undefined as T
  }

  if (response.status === 200) {
    return (await response.json()) as T
  }

  const $toast = useToast()
  $toast.error("Network error")
  throw new Error(JSON.stringify(response))
}
