using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.BillingInterface
{
    public interface BillingManager
    {
        /// <summary>
        ///  잔액조회
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int GetBalance();
        /// <summary>
        ///  Cash 추가
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int InsertCash(int cashAmount);
        /// <summary>
        ///  Caash 전액환불
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int RefundCash(int cashNo);
        /// <summary>
        ///  아이템 구매
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int PurchaseItem(int itemNo);
        /// <summary>
        ///  아이템 구매취소
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int PurchaseCancelItem(int purchaseNo);
        /// <summary>
        /// 현재 사용자 보유 아이템내역 출력
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int PrintItemList();
        /// <summary>
        /// 현재 사용자 보유 캐시내역만 출력
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int PrintCashList();
        /// <summary>
        /// 모든 아이템 구매/취소 내역출력
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int PrintItemPurchaseHistory(List<BillingManager> objList);
        /// <summary>
        /// 모든 캐시 추가/환불 내역출력
        /// </summary>
        /// <returns>0 성공, 이외 값은 실패</returns>
        int PrintCashHistory(List<BillingManager> objList);
    }
}
