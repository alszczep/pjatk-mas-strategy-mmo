<script setup lang="ts">
  import type { BuildableBuildingDTO, BuildingDetailsDTO } from "../../api/dtos"
  import ResourcesRow from "../common/ResourcesRow.vue"

  const { buildings, villageId } = defineProps<{
    buildings: BuildableBuildingDTO[]
    villageId: string
  }>()

  const build = () => {
    alert("TODO")
  }
</script>

<template>
  <v-card class="wrapper">
    <v-card-title>Choose a building to build</v-card-title>
    <v-card-text class="text">
      <div v-for="building in buildings" :key="building.id" class="building">
        <img :src="building.imageUrl" class="image" />
        <div class="info">
          <div>{{ building.name }}</div>
          <ResourcesRow
            variant="tonal"
            class="resources"
            :values="building.cost"
          />
        </div>
        <v-btn variant="tonal" class="button" @click="build">Build</v-btn>
      </div>
    </v-card-text>
  </v-card>
</template>

<style scoped>
  .wrapper {
    width: 100%;
  }

  .text {
    display: flex;
    flex-direction: column;
  }

  .building {
    display: flex;
    gap: 24px;
    align-items: center;
  }

  .image {
    width: 96px;
    height: 96px;
  }

  .info {
    display: flex;
    flex-direction: column;
    gap: 8px;
  }

  .resources {
    width: 450px;
  }

  .button {
    margin-left: auto;
    margin-top: 16px;
  }
</style>
