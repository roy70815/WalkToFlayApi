export interface ApiResult<T> {
  id: string;
  /**
   * API版本
   */
  apiVersion: string;
  /**
   * 方法名稱
   */
  method: string;
  data:T
}
