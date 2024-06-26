<script setup lang="ts">
  import type { VillageDetailsBuildingDTO } from "../../api/dtos/VillageDetailsDTO"
  import Building from "./Building.vue"

  import {
    buildingGridHeight,
    buildingGridWidth,
    buildingPlaceToGridPosition,
  } from "./buildingsGridConfig"
  import { computed } from "vue"

  const { buildings, villageId } = defineProps<{
    buildings: VillageDetailsBuildingDTO[]
    villageId: string
  }>()

  const appendSizeToGridPosition = (position: {
    gridRow: number
    gridColumn: number
  }) => {
    const heightHalf = Math.floor(buildingGridHeight / 2)
    const widthHalf = Math.floor(buildingGridWidth / 2)
    return {
      gridRow: `${position.gridRow - heightHalf} / ${position.gridRow + heightHalf}`,
      gridColumn: `${position.gridColumn - widthHalf} / ${position.gridColumn + widthHalf}`,
    }
  }

  const buildingsWithPosition = computed(() =>
    buildingPlaceToGridPosition.map((position, index) => {
      return {
        ...buildings.find((building) => building.buildingSpot === index),
        ...appendSizeToGridPosition(position),
        place: index,
      }
    }),
  )
</script>

<template>
  <div class="buildings-grid">
    <div
      v-for="building in buildingsWithPosition"
      :key="building.place"
      class="building-wrapper"
      :style="{ gridRow: building.gridRow, gridColumn: building.gridColumn }"
    >
      <Building
        :image-url="building.imageUrl"
        :level="building.level"
        :place-in-village="building.place"
        :village-id="villageId"
      />
    </div>
  </div>
</template>

<style scoped>
  .buildings-grid {
    display: grid;
    grid-template: repeat(45, 1fr) / repeat(50, 1fr);

    width: 800px;
    height: 550px;
  }
</style>
