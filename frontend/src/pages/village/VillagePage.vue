<script setup lang="ts">
  import { ref } from "vue"
  import { logOut } from "../../auth/logOut"
  import { ownerVillageEndpoint } from "../../api/endpoints"

  const villageName = ref<string>()

  async function fetchOwnersVillage() {
    villageName.value = (await ownerVillageEndpoint()).name
  }
  fetchOwnersVillage()
</script>

<template>
  <div class="page-wrapper">
    <v-btn @click="logOut">LOG OUT</v-btn>
    <h1>{{ villageName }}</h1>
  </div>
</template>

<style scoped>
  .page-wrapper {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
  }
</style>
