import { IAddress } from "./address"
import { IMark } from "./mark"
import { ITrainingCategory } from "./trainingCategory"

export interface IStudent {
    id: number
    firstName: string
    lastName: string
    email: string
    phone: string
    age: number
    registrationDate: string
    address: IAddress
    addressId: number
    trainingCategory: ITrainingCategory
    trainingCategoryId: number
    mark: IMark
    markId: number
    examType: number
    startDate: string
  }
  