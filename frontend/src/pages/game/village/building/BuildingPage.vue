<script setup lang="ts">
  import { useRoute } from "vue-router"
  import { routes } from "../../../../routes"
  import type {
    BuildableBuildingDTO,
    BuildingDetailsDTO,
  } from "../../../../api/dtos"
  import ResourcesRow from "../../../../components/common/ResourcesRow.vue"
  import WholePageLoader from "../../../../components/common/WholePageLoader.vue"
  import BuildableBuildingsList from "../../../../components/building/BuildableBuildingsList.vue"
  import BuildingDetails from "../../../../components/building/BuildingDetails.vue"
  import {
    getBuildableBuildingsEndpoint,
    getBuildingDetailsEndpoint,
    villageByIdEndpoint,
  } from "../../../../api/endpoints"
  import { ref } from "vue"
  import type { VillageDetailsDTO } from "../../../../api/dtos/VillageDetailsDTO"

  const route = useRoute()
  const villageId = route.params[routes.game.village.param] as string
  const placeInVillage = route.params[
    routes.game.village.building.param
  ] as string

  const village = ref<VillageDetailsDTO>()

  async function fetchVillage() {
    if (villageId === undefined) {
      return
    }

    village.value = await villageByIdEndpoint(villageId)
  }
  fetchVillage()

  const buildingDetails = ref<BuildingDetailsDTO>()
  const buildableBuildings = ref<BuildableBuildingDTO[]>()

  async function fetchBuilding() {
    if (villageId === undefined || placeInVillage === undefined) {
      return
    }

    buildingDetails.value = await getBuildingDetailsEndpoint(
      villageId,
      Number(placeInVillage),
    )
    if (!buildingDetails.value) {
      buildableBuildings.value = await getBuildableBuildingsEndpoint(villageId)
    }
  }
  fetchBuilding()
</script>

<template>
  <WholePageLoader
    v-if="!village || (!buildingDetails && !buildableBuildings)"
  />
  <div class="page-wrapper" v-else>
    <ResourcesRow :values="village.availableResources" class="resources" />
    <BuildableBuildingsList
      v-if="!buildingDetails && buildableBuildings"
      :buildings="buildableBuildings"
      :village-id="villageId"
    />
    <BuildingDetails
      v-if="buildingDetails"
      :village-id="villageId"
      :building="buildingDetails"
    />
  </div>
</template>

<style scoped>
  .page-wrapper {
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .resources {
    margin-bottom: 8px;
  }
</style>
