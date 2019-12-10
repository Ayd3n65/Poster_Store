export interface Pagination {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
}
export class PaginatedResult<T> {
    result: T; // сохраняем сюда постеры или юзеров
    pagination: Pagination;
}
