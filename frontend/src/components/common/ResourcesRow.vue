<script setup lang="ts">
  import type { ResourceDTO } from "../../api/dtos"

  const { values } = defineProps<{
    values: ResourceDTO
  }>()
</script>

<template>
  <div class="wrapper">
    <div>
      <img src="../../assets/wood.bmp" />
      <div>{{ values.wood }}</div>
    </div>
    <div>
      <img src="../../assets/iron.bmp" />
      <div>{{ values.iron }}</div>
    </div>
    <div>
      <img src="../../assets/wheat.bmp" />
      <div>{{ values.wheat }}</div>
    </div>
    <div>
      <img src="../../assets/gold.bmp" />
      <div>{{ values.gold }}</div>
    </div>
  </div>
</template>

<style scoped>
  .wrapper {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    width: 100%;
  }

  .wrapper > div {
    display: flex;
    gap: 8px;
  }

  .wrapper > div > img {
    width: 20px;
    height: 20px;
  }
</style>
