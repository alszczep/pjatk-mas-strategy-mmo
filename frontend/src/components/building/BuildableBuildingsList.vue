<script setup lang="ts">
  import { useToast } from "vue-toast-notification"
  import type { BuildableBuildingDTO } from "../../api/dtos/BuildableBuildingDTO"
  import ResourcesRow from "../common/ResourcesRow.vue"
  import { scheduleBuildingEndpoint } from "../../api/endpoints"
  import { router, routes } from "../../routes"

  const { buildings, placeInVillage, villageId } = defineProps<{
    buildings: BuildableBuildingDTO[]
    placeInVillage: number
    villageId: string
  }>()

  const $toast = useToast()

  const build = async (buildingId: string) => {
    scheduleBuildingEndpoint(villageId, placeInVillage, buildingId).then(() => {
      router.push(routes.game.village.withParam(villageId))
    })
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
        <v-btn variant="tonal" class="button" @click="() => build(building.id)"
          >Build</v-btn
        >
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
