/// <reference types='vitest' />
import { defineConfig } from "vite"
import vue from "@vitejs/plugin-vue"
import { nxViteTsPaths } from "@nx/vite/plugins/nx-tsconfig-paths.plugin"
import { checker } from "vite-plugin-checker"

export default defineConfig({
  root: __dirname,
  cacheDir: "./node_modules/.vite/.",

  server: {
    port: 4200,
    host: "localhost",
  },

  preview: {
    port: 4300,
    host: "localhost",
  },

  plugins: [
    vue(),
    nxViteTsPaths(),
    checker({
      typescript: {
        root: process.cwd(),
        tsconfigPath: "tsconfig.app.json",
      },
    }),
  ],

  build: {
    outDir: "./dist/frontend",
    reportCompressedSize: true,
    commonjsOptions: {
      transformMixedEsModules: true,
    },
  },
})
