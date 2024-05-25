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
      Authorization: `Bearer ${localStorage.getItem("authToken")}`,
      credentials: "include",
      ...options?.headers,
    },
    ...options,
  })
  return await response.json()
}
